using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Common.AsmdefGraph
{
    public class AsmdefGraphView : GraphView
    {
        private readonly Vector2 _defaultNodeSize = new(150, 200);
        
        public AsmdefGraphView()
        {
            styleSheets.Add(UnityEngine.Resources.Load<StyleSheet>("AsmdefGraph"));
            
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
            
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
            zoomerMaxElementCountWithPixelCacheRegen = 30;

            var grid = new GridBackground();
            Insert(0, grid);
            grid.StretchToParentSize();
        }

        public AsmdefNode CreateNode(string nodeName, Vector2 position, AssemblyEntry entry)
        {
            var guid = Guid.NewGuid().ToString();

            var node = new AsmdefNode(guid, entry, this)
            {
                title = nodeName,
            };
            
            node.RefreshExpandedState();
            node.RefreshPorts();
            
            node.SetPosition(new Rect(position, _defaultNodeSize));

            AddElement(node);
            
            return node;
        }

        // private void AddChoicePort(AsmdefNode node)
        // {
        //     var generatedPort = GeneratePort(node, Direction.Output);
        //
        //     var outputPortCount = node.outputContainer.Query("connector").ToList().Count;
        //    generatedPort.portName = $"Choice {outputPortCount}";
        //
        //     node.outputContainer.Add(generatedPort);
        //     node.RefreshPorts();
        //     node.RefreshExpandedState();
        // }
        
        // private AsmdefNode GenerateEntryPointNode()
        // {
        //     var node = new AsmdefNode()
        //     {
        //         title = "Start",
        //         GUID = Guid.NewGuid().ToString(),
        //         Text = "asdf",
        //         EntryPoint = true
        //     };
        //     
        //     node.SetPosition(new Rect(Vector2.zero, _defaultNodeSize));
        //
        //     var port = GeneratePort(node, Direction.Output);
        //     port.portName = "Next";
        //     node.outputContainer.Add(port);
        //     
        //     node.RefreshExpandedState();
        //     node.RefreshPorts();
        //     
        //     return node;
        // }

        // private Port CreatePort(AsmdefNode node, Direction direction, string portName)
        // {
        //     var port =  node.InstantiatePort(Orientation.Horizontal, direction, Port.Capacity.Multi, typeof(float));
        //     port.portName = portName;
        //     node.outputContainer.Add(port);
        //
        //     return port;
        // }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            var compatiblePorts = new List<Port>();

            ports.ForEach(port =>
            {
                if (startPort != port && startPort.node != port.node)
                    compatiblePorts.Add(port);
            });

            return compatiblePorts;
        }
    }
}