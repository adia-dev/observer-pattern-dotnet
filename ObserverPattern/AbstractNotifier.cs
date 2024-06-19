public abstract class AbstractNotifier
{
    protected readonly Dictionary<string, List<ISubscriber>> _topicSubscribers;

    public AbstractNotifier()
    {
        _topicSubscribers = new Dictionary<string, List<ISubscriber>>();
    }

    public virtual void Subscribe(string topic, ISubscriber subscriber)
    {
        if (!_topicSubscribers.ContainsKey(topic))
        {
            _topicSubscribers[topic] = new List<ISubscriber>();
        }

        if (_topicSubscribers[topic].Contains(subscriber))
        {
            return;
        }

        _topicSubscribers[topic].Add(subscriber);
    }

    public virtual void Unsubscribe(string topic, ISubscriber subscriber)
    {
        if (!_topicSubscribers.ContainsKey(topic) ||
            !_topicSubscribers[topic].Contains(subscriber))
        {
            return;
        }

        _topicSubscribers[topic].Remove(subscriber);
    }

    public abstract void Notify(string topic);
}
