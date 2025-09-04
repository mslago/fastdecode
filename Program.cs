using Orbipacket;

class Program
{
    static void Main(string[] args)
    {
        string hex = args[0];
        Console.WriteLine("Input Hex: " + hex);
        hex = hex.Replace(" ", "")
            .Replace("\n", "")
            .Replace("\r", "")
            .Replace("\t", "")
            .Replace("-", "");
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }

        Console.WriteLine("Input Bytes: " + Convert.ToHexString(bytes));

        PacketBuffer buffer = new();
        buffer.Add(bytes);
        byte[]? packetbytes = buffer.ExtractFirstValidPacket();

        if (packetbytes == null)
        {
            Console.WriteLine("No valid packet found");
            return;
        }
        else
        {
            Packet packet = Decode.GetPacketInformation(packetbytes);
            Console.WriteLine(
                "Packet Type: {0}\n"
                    + "Packet Version: {1}\n"
                    + "Packet Timestamp: {2}\n"
                    + "Packet Payload (hex): {3}\n"
                    + "Packet Payload (converted to string): {4}",
                packet.Type,
                packet.Version,
                packet.Timestamp,
                Convert.ToHexString(packet.Payload.Value),
                System.Text.Encoding.UTF8.GetString(packet.Payload.Value)
            );
        }
    }
}
