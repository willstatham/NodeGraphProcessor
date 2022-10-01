using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace GraphProcessor
{
    public class SubGraphSchemaGUIUtility
    {
        readonly SubGraphPortSchema _schema;
        SerializedObject _subGraphSerialized;
        SerializedProperty _ingressPortDataSerialized;
        SerializedProperty _egressPortDataSerialized;

        public SubGraphSchemaGUIUtility(SubGraphPortSchema schema)
        {
            this._schema = schema;
        }

        public SubGraphPortSchema Schema => _schema;

        public SerializedObject SchemaObject =>
            PropertyUtils.LazyLoad(
                ref _subGraphSerialized,
                () => new SerializedObject(Schema)
            );

        public SerializedProperty IngressPortData =>
            PropertyUtils.LazyLoad(
                ref _ingressPortDataSerialized,
                () => SchemaObject.FindProperty(SubGraphPortSchema.IngressPortDataFieldName)
            );

        public SerializedProperty EgressPortData =>
            PropertyUtils.LazyLoad(
                ref _egressPortDataSerialized,
                () => SchemaObject.FindProperty(SubGraphPortSchema.EgressPortDataFieldName)
            );

        public VisualElement DrawFullSchemaGUI()
        {
            var schemaControlsContainer = new VisualElement();

            schemaControlsContainer.Add(DrawIngressPortSelectorGUI(bind: false));
            schemaControlsContainer.Add(DrawEgressPortSelectorGUI(bind: false));
            schemaControlsContainer.Add(DrawSchemaUpdaterButtonGUI());

            schemaControlsContainer.Bind(SchemaObject);

            return schemaControlsContainer;
        }

        public PropertyField DrawIngressPortSelectorGUI(bool bind = true)
        {
            var ingressDataField = new PropertyField(IngressPortData) { label = "Ingress Port Data - Schema" };
            if (bind) ingressDataField.Bind(SchemaObject);
            return ingressDataField;
        }

        public PropertyField DrawEgressPortSelectorGUI(bool bind = true)
        {
            var egressDataField = new PropertyField(EgressPortData) { label = "Egress Port Data - Schema" };
            if (bind) egressDataField.Bind(SchemaObject);
            return egressDataField;
        }

        public Button DrawSchemaUpdaterButtonGUI()
        {
            var updatePortsButton = new Button(() => Schema.NotifyPortsChanged()) { text = "UPDATE SCHEMA" };
            return updatePortsButton;
        }
    }
}