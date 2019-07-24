namespace Abp.Events.Bus
{
    /// <summary>
    /// �˽ӿڱ����ɾ��е������Ͳ������¼�������ʵ�֣����Ҵ˲������ɼ̳�ʹ�á� 
    /// ������evendata�̳�������ӿڡ��Ϳ��԰��ռ̳в��������������¼�
    /// For example;
    /// Assume that Student inherits From Person. When trigger an EntityCreatedEventData{Student},
    /// EntityCreatedEventData{Person} is also triggered if EntityCreatedEventData implements
    /// this interface.
    /// </summary>
    public interface IEventDataWithInheritableGenericArgument
    {
        /// <summary>
        /// Gets arguments to create this class since a new instance of this class is created.
        /// </summary>
        /// <returns>Constructor arguments</returns>
        object[] GetConstructorArgs();
    }
}