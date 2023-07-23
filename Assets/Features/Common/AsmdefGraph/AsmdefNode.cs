using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace Common.AsmdefGraph
{
    public class AsmdefNode : Node
    {
        public AsmdefNode(string guid, AssemblyEntry assembly, AsmdefGraphView graph)
        {
            GUID = guid;
            _assembly = assembly;
            _graph = graph;

            _input = CreateInputPort();
            _output = CreateOutputPort();
        }

        public readonly string GUID;
        private readonly AssemblyEntry _assembly;
        private readonly AsmdefGraphView _graph;

        private readonly Port _output;
        private readonly Port _input;

        private readonly List<Edge> _edges = new();

        public void ConnectTo(AsmdefNode target)
        {
            var edge = _output.ConnectTo(target._input);
            
            _edges.Add(edge);
        }

        public void Refresh()
        {
            RefreshExpandedState();
            RefreshPorts();
            
            foreach (var edge in _edges)
                _graph.Add(edge);
            
            RefreshExpandedState();
            RefreshPorts();
        }

        private Port CreateOutputPort()
        {
            var port = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(float));
            port.portName = "To";
            outputContainer.Add(port);

            return port;
        }

        public Port CreateInputPort()
        {
            var port = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(float));
            port.portName = "By";
            outputContainer.Add(port);

            return port;
        }
    }
}