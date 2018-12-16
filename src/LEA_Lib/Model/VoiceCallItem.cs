using System;

namespace LEA.Lib.Model
{
    public sealed class VoiceCallItem
    {
        public int ProductId { get; set; }
        public String Path { get; set; }
        public int CallLengthInMs { get; set; }
    }
}
