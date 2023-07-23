using Common.Architecture.Local.Services.Abstract.Callbacks;
using GamePlay.Services.LevelCameras.Logs;
using Global.Services.Cameras.CurrentCameras.Runtime;
using Global.Services.Inputs.View.Runtime.Projection;
using Global.Services.System.Updaters.Runtime.Abstract;
using UnityEngine;
using VContainer;

namespace GamePlay.Services.LevelCameras.Runtime
{
    public class LevelCamera :
        MonoBehaviour,
        ILevelCamera,
        IPostFixedUpdatable,
        ILocalAwakeListener,
        ILocalSwitchListener
    {
        [Inject]
        private void Construct(
            ICurrentCamera currentCamera,
            IInputProjection inputProjection,
            ILevelCameraConfig config,
            IUpdater updater,
            LevelCameraLogger logger)
        {
            _updater = updater;
            _config = config;
            _inputProjection = inputProjection;
            _logger = logger;
            _currentCamera = currentCamera;

            _transform = transform;
        }

        private const float _offsetZ = -10f;

        private Camera _camera;
        private ICurrentCamera _currentCamera;

        private LevelCameraLogger _logger;

        private Transform _target;

        private Transform _transform;
        private IInputProjection _inputProjection;
        private ILevelCameraConfig _config;
        private IUpdater _updater;

        public Camera Camera => _camera;

        public void OnEnabled()
        {
            _updater.Add(this);
        }

        public void OnDisabled()
        {
            _updater.Remove(this);
        }
        
        public void StartFollow(Transform target)
        {
            _target = target;

            _logger.OnStartFollow(target.name);
        }

        public void StopFollow()
        {
            if (_target == null)
            {
                _logger.OnStopFollowError();
                return;
            }

            _logger.OnStopFollow(_target.name);

            _target = null;
        }

        public void Teleport(Vector2 target)
        {
            var position = new Vector3(target.x, target.y, _offsetZ);
            _transform.position = position;

            _logger.OnTeleport(position);
        }

        public void SetSize(float size)
        {
            _camera.orthographicSize = size;
        }

        public void OnAwake()
        {
            _camera = GetComponent<Camera>();
            _currentCamera.SetCamera(_camera);
        }
        
        public void OnPostFixedUpdate(float delta)
        {
            if (_target == null)
                return;

            var targetPosition = _target.position;
            var line = _inputProjection.GetLineFrom(targetPosition);

            var distanceToCursor =
                line.Length - Vector2.Distance(targetPosition, _transform.position);

            var sight = _config.CreateSight(line.Direction, distanceToCursor);

            if (sight.IsOversight == true)
                targetPosition += sight.CreateOversightMove();

            var speed = _config.FollowSpeed * delta;
            var position = Vector3.Lerp(_transform.position, targetPosition, speed);
            position.z = _offsetZ;

            _transform.position = position;
        }
    }
}