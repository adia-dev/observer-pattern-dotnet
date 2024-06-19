namespace ObserverPattern.Kafka;

public class Kafka
{
    private readonly Dictionary<string, List<string>> _topicMessages;
    private readonly KafkaStream _kafkaStream;

    public Kafka(KafkaStream kafkaStream)
    {
        _topicMessages = new Dictionary<string, List<string>>();
        _kafkaStream = kafkaStream;
    }

    public void AddMessage(string topic, string message)
    {
        if (_topicMessages.ContainsKey(topic))
        {
            _topicMessages[topic].Add(message);
        }
        else
        {
            _topicMessages.Add(topic, new List<string> { message });
        }

        _kafkaStream.Notify(topic);
    }
}
