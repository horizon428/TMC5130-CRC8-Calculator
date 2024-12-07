# TMC5130 CRC8 Calculator

这是一个用于TMC5130步进电机驱动器通信的CRC8校验计算器。它实现了TMC5130通信协议中使用的CRC8校验算法。

## 特性

- 使用多项式 0x07 (x⁸ + x² + x¹ + x⁰)
- 支持从MSB到LSB的位处理
- 提供两种计算方法：
  - `CalculateCRC`: 直接修改输入数组，在最后一个字节存储CRC值
  - `CalculateCRCValue`: 返回CRC值而不修改输入数组

## 使用方法

```csharp
// 方法1：直接计算并修改数组
byte[] datagram = new byte[] { 0x05, 0x00, 0x02, 0x00 }; // 最后一个字节用于存储CRC
CRC8Calculator.CalculateCRC(datagram, datagram.Length);
// 现在datagram[3]包含了CRC值

// 方法2：获取CRC值而不修改原数组
byte[] data = new byte[] { 0x05, 0x00, 0x02 };
byte crc = CRC8Calculator.CalculateCRCValue(data);
```

## 测试

项目包含了完整的测试套件，涵盖了：
- 实际TMC5130通信数据测试
- 读取寄存器命令测试
- 寄存器读取响应测试
- 写入寄存器命令测试
- 计算方法一致性测试

## 开发环境

- .NET 6.0
- Visual Studio 2022 或 VS Code
- MSTest 测试框架

## 许可证

MIT License
