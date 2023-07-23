using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Common.AsmdefGraph
{
    public class AsmdefGraph : EditorWindow
    {
        private const float _groupXStep = 1000f;
        private const float _groupYStep = 100f;
        private const float _lineYStep = 80f;

        private AsmdefGraphView _view;
        private readonly Dictionary<AssemblyEntry, AsmdefNode> _nodes;

        public AsmdefGraph()
        {
            _nodes = new Dictionary<AssemblyEntry, AsmdefNode>();
        }

        [MenuItem("Tools/AsmdefGraph")]
        public static void Open()
        {
            var window = GetWindow<AsmdefGraph>();
            window.titleContent = new GUIContent("Asmdef graph");
        }

        private void OnEnable()
        {
            Debug.Log("Enable");

            ConstructGraph();
            GenerateToolBar();
        }

        private void OnDisable()
        {
            rootVisualElement.Remove(_view);
        }

        private void ConstructGraph()
        {
            _view = new AsmdefGraphView()
            {
                name = "Asmdef graph"
            };

            _view.StretchToParentSize();
            rootVisualElement.Add(_view);

            _nodes.Clear();

            var assemblyCollector = new AssemblyCollector();

            var assemblies = assemblyCollector.Collect();

            var orderedAssemblies = assemblies
                .OrderByDescending(x => x.Dependencies.Count)
                .ToList();

            var startPosition = Vector2.zero;

            foreach (var assembly in orderedAssemblies)
            {
                var height = CreateDependencyNodes(assembly, startPosition);

                break;
                startPosition.y += height;
            }

            foreach (var assembly in assemblies)
            {
                ConnectNodes(assembly);
            }

            foreach (var (_, node) in _nodes)
            {
                node.Refresh();
            }
        }

        private float CreateDependencyNodes(AssemblyEntry entry, Vector2 nodePosition)
        {
            var height = 0f;

            if (_nodes.ContainsKey(entry) == false)
            {
                var node = _view.CreateNode(entry.Name, nodePosition, entry);

                _nodes.Add(entry, node);
            }

            nodePosition.x += _groupXStep;

            foreach (var dependency in entry.Dependencies)
            {
                if (_nodes.ContainsKey(dependency) == false)
                {
                    var node = _view.CreateNode(dependency.Name, nodePosition, dependency);

                    _nodes.Add(dependency, node);
                    nodePosition.y += _groupYStep;
                    height += _groupYStep;
                }

                var additionalHeight = CreateDependencyNodes(dependency, nodePosition);

                nodePosition.y += additionalHeight;
                height += additionalHeight;
            }

            return height;
        }

        private void ConnectNodes(AssemblyEntry entry)
        {
            if (entry.Dependencies.Count == 0)
                return;

            if (_nodes.ContainsKey(entry) == false)
                return;

            var node = _nodes[entry];

            foreach (var dependency in entry.Dependencies)
            {
                node.ConnectTo(_nodes[dependency]); 
                ConnectNodes(dependency);
            }
        }

        private void GenerateToolBar()
        {
            // var toolbar = new Toolbar();
            //
            // var nodeCreateButton = new Button(() => { _view.CreateNode("Node"); });
            // nodeCreateButton.text = "Create node";
            // toolbar.Add(nodeCreateButton);
            //
            // rootVisualElement.Add(toolbar);
        }
    }
}