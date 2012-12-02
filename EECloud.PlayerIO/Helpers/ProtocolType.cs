namespace EECloud.PlayerIO
{
    internal enum ProtocolType : byte
    {
        Binary,
        Http = 71,
        Auto = 255,
        WebsocketRfc6544Binary = 11,
        WebsocketV76Base64
    }
}
