using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Menu.Collections.Global;
using Menu.Common.Navigation;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Collections.UI
{
    [DisallowMultipleComponent]
    public class CollectionsView : MonoBehaviour, ICollectionsView
    {
        [SerializeField] private float _switchTime = 0.05f;
        [SerializeField] private CollectionEntryView[] _entries;
        
        [SerializeField] private Button _previousPageButton;
        [SerializeField] private Button _nextPageButton;
        
        private ITabNavigation _navigation;
        private RectTransform _transform;

        private int _page;
        private int _totalPagesCount;
        private bool _isOpened;

        private CancellationTokenSource _cancellation;
        
        private IReadOnlyList<AvatarHandle> _avatars;

        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform => _transform;

        private void Awake()
        {
            _navigation = GetComponent<ITabNavigation>();
            _transform = GetComponent<RectTransform>();
        }

        public void Enable()
        {
            _previousPageButton.onClick.AddListener(OnLeftPageClicked);
            _nextPageButton.onClick.AddListener(OnRightPageClicked);
        }
        
        public void Disable()
        {
            _previousPageButton.onClick.RemoveListener(OnLeftPageClicked);
            _nextPageButton.onClick.RemoveListener(OnRightPageClicked);

            _isOpened = false;
        }
        
        public void Construct(IReadOnlyList<AvatarHandle> achievement)
        {
            _avatars = achievement;
            _totalPagesCount = achievement.Count / _entries.Length;
        }

        public void Open()
        {
            _page = 0;
            
            Cancel();
            _cancellation = new CancellationTokenSource();
            ShowPage(_page, _cancellation.Token).Forget();
        }

        private void OnLeftPageClicked()
        {
            _page--;
            
            Cancel();
            _cancellation = new CancellationTokenSource();
            
            ShowPage(_page, _cancellation.Token).Forget();
        }
        
        private void OnRightPageClicked()
        {
            _page++;
            
            Cancel();
            _cancellation = new CancellationTokenSource();
            
            ShowPage(_page, _cancellation.Token).Forget();
        }

        private async UniTask ShowPage(int page, CancellationToken cancellation)
        {
            if (page == 0)
                _previousPageButton.gameObject.SetActive(false);
            else
                _previousPageButton.gameObject.SetActive(true);
            
            if (page == _totalPagesCount)
                _nextPageButton.gameObject.SetActive(false);
            else
                _nextPageButton.gameObject.SetActive(true);
            
            if (_isOpened == true)
            {
                var entries = new List<UniTask>();
                
                foreach (var entry in _entries)
                {
                    var task = entry.Hide(cancellation);
                    entries.Add(task);
                    await UniTask.Delay(_switchTime);
                }
            
                await UniTask.WhenAll(entries);
            }
            
            _isOpened = true;

            var start = page * _entries.Length;
            int lastIndex;

            if (start + _entries.Length >= _avatars.Count)
                lastIndex = _avatars.Count;
            else
                lastIndex = start + _entries.Length;
            
            var entryCounter = 0;
            var list = new List<UniTask>();
            
            for (var i = start; i < lastIndex; i++)
            {
                var task = _entries[entryCounter].Show(_avatars[i], cancellation);
                list.Add(task);
                entryCounter++;

                await UniTask.Yield(cancellation);
            }
            
            await UniTask.WhenAll(list);
        }
        
        private void Cancel()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}