namespace ObserverPattern.Kafka;

public class KafkaStream : AbstractNotifier
{
    public bool IsRunning { get; private set; } = true;

    public override void Notify(string topic)
    {
        if (_topicSubscribers.ContainsKey(topic))
        {
            _topicSubscribers[topic].ForEach(subscriber => subscriber.update());
        }
    }
}
