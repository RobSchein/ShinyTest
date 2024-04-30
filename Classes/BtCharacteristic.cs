using Shiny.BluetoothLE;
using System.Reactive.Linq;

namespace MyNamespace.Classes {
   public class CBtCharacteristic {
      private BleCharacteristicInfo? Characteristic { get; set; }
      private readonly IPeripheral? Peripheral;
      public int Value = 0;

      public CBtCharacteristic(IPeripheral peripheral, BleCharacteristicInfo characteristic) {
         Peripheral = peripheral;
         Characteristic = characteristic;
      }
      public async void Write(byte[] value) {
         if (Peripheral != null && Characteristic != null && Characteristic.CanWrite()) {
            await Peripheral.WriteCharacteristic(Characteristic, value);
         }
      }
      public async Task Read() {
         if (Peripheral != null && Characteristic != null) {
            var Result = await Peripheral.ReadCharacteristic(Characteristic);
            if (Result != null && Result.Data != null && Result.Data.Length > 0) 
               Value = BitConverter.ToInt32(Result.Data, 0);
         }
      }
   }
}
