using System;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

namespace Assets.Source.Scripts.BehaviourTreeAI.Editor
{
    public class NodeView : UnityEditor.Experimental.GraphView.Node
    {
        public Node node;
        public Port Input;
        public Port Output;

        public NodeView(Node node)
        {
            this.node = node;
            this.title = node.name;
            this.viewDataKey = node.Id;


            style.left = node.UIPosition.x;
            style.top = node.UIPosition.y;

            CreateInputPorts();
            CreateOutputPorts();
        }

        private void CreateInputPorts()
        {
            if(node is ActionNode)
            {
                Input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
            }
            else if(node is CompositeNode)
            {
                Input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
            }
            else if(node is DecoratorNode)
            {
                Input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
            }

            if (Input != null)
            {
                Input.portName = "";
                inputContainer.Add(Input);

            }
        }

        private void CreateOutputPorts()
        {
            if (node is CompositeNode)
            {
                Output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
            }
            else if (node is DecoratorNode)
            {
                Output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
            }

            if (Output != null)
            {
                Output.portName = "";
                outputContainer.Add(Output);

            }
        }

        public override void SetPosition(Rect newPos)
        {
            base.SetPosition(newPos);

            node.UIPosition.x = newPos.xMin;
            node.UIPosition.y = newPos.yMin;
        }
    }
}
