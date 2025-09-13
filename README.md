# Orbipacket Fast Decode - Quickly decode your encoded packets
This CLI tool eases the decoding of any type of packet encoded with the Orbipacket protocol.
## Usage
To use, simply run:
```csharp
dotnet run {packet-bytes}
```
The produced output will result in a readable format of the packet's information:
```
Input Hex: 13-01-05-0C-C0-8F-48-D7-A0-1F-62-18-43-68-65-63-6B-83-CE-00
Input Bytes: 1301050CC08F48D7A01F6218436865636B83CE00
Packet without initial 0x00 byte found
Packet Type: TmPacket
Packet Version: 1
Packet Timestamp: 1757001580295000000
Packet Payload (hex): 436865636B
Packet Payload (converted to string): Check
```
Packet payload conversion to a readable format based on the packet type is yet to be implemented.
