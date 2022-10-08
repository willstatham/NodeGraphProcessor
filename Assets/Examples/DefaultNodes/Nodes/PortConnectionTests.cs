using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;
using System.Linq;

[System.Serializable, NodeMenuItem("Custom/PortConnectionTests")]
public class PortConnectionTests : BaseNode
{
    [Input]
    public IEnumerable<object> inputs = null;

    [Output]
    public IEnumerable<object> outputs;

    public float padding;

    public override string name => "Port Tests";

    protected override void Process() { }

    [CustomPortBehavior(nameof(inputs))]
    IEnumerable<PortData> GetPortsForInputs(List<SerializableEdge> edges)
    {
        yield return new PortData { displayName = "In 0", DisplayType = typeof(float), identifier = "0" };
        yield return new PortData { displayName = "In 1", DisplayType = typeof(Color), identifier = "1" };
        yield return new PortData { displayName = "In 2", DisplayType = typeof(Vector4), identifier = "2" };
        yield return new PortData { displayName = "In 3", DisplayType = typeof(GameObject), identifier = "3" };
        yield return new PortData { displayName = "In 4", DisplayType = typeof(float), identifier = "4" };
        yield return new PortData { displayName = "In 5", DisplayType = typeof(Color), identifier = "5" };
        yield return new PortData { displayName = "In 6", DisplayType = typeof(Vector4), identifier = "6" };
        yield return new PortData { displayName = "In 7", DisplayType = typeof(GameObject), identifier = "7" };
    }

    [CustomPortBehavior(nameof(outputs))]
    IEnumerable<PortData> GetPortsForOutput(List<SerializableEdge> edges)
    {
        yield return new PortData { displayName = "Out 0", DisplayType = typeof(float), identifier = "0" };
        yield return new PortData { displayName = "Out 1", DisplayType = typeof(Color), identifier = "1" };
        yield return new PortData { displayName = "Out 2", DisplayType = typeof(Vector4), identifier = "2" };
        yield return new PortData { displayName = "Out 3", DisplayType = typeof(GameObject), identifier = "3" };
        yield return new PortData { displayName = "Out 4", DisplayType = typeof(float), identifier = "4" };
        yield return new PortData { displayName = "Out 5", DisplayType = typeof(Color), identifier = "5" };
        yield return new PortData { displayName = "Out 6", DisplayType = typeof(Vector4), identifier = "6" };
        yield return new PortData { displayName = "Out 7", DisplayType = typeof(GameObject), identifier = "7" };
    }
}
