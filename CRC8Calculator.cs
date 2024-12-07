using System;

public class CRC8Calculator
{
    public static void CalculateCRC(byte[] datagram, int datagramLength)
    {
        // CRC located in last byte of message
        int crcIndex = datagramLength - 1;
        datagram[crcIndex] = 0;

        // Execute for all bytes of a message
        for (int i = 0; i < datagramLength - 1; i++)
        {
            byte currentByte = datagram[i];
            
            // Process each bit of the byte
            for (int j = 0; j < 8; j++)
            {
                // Compare CRC.7 with current bit
                if (((datagram[crcIndex] >> 7) ^ (currentByte & 0x01)) != 0)
                {
                    datagram[crcIndex] = (byte)((datagram[crcIndex] << 1) ^ 0x07);
                }
                else
                {
                    datagram[crcIndex] = (byte)(datagram[crcIndex] << 1);
                }
                
                currentByte = (byte)(currentByte >> 1);
            }
        }
    }

    // Helper method to calculate CRC and return the value without modifying the input array
    public static byte CalculateCRCValue(byte[] data)
    {
        byte[] datagramCopy = new byte[data.Length + 1];
        Array.Copy(data, datagramCopy, data.Length);
        CalculateCRC(datagramCopy, datagramCopy.Length);
        return datagramCopy[datagramCopy.Length - 1];
    }
}
