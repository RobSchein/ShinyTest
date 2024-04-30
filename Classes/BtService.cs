using Shiny.BluetoothLE;

namespace MyNamespace.Classes {
   public class CBtService {
      private IPeripheral? Peripheral;
      private BleServiceInfo? Service { get; set; }
      public CBtCharacteristics Characteristics;

      public CBtService(IPeripheral peripheral, BleServiceInfo service) {
         Peripheral = peripheral;
         Service    = service;
         Characteristics = new CBtCharacteristics(Peripheral);
      }

      public async Task Scan(IPeripheral Peripheral) {
         if (Service != null)
            await Characteristics.Scan(Service);
      }
   }
}
