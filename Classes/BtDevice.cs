using Shiny.BluetoothLE;

namespace MyNamespace.Classes {
   public class CBtDevice {
      public IPeripheral Peripheral;
      public CBtServices Services;

      public CBtDevice(IPeripheral peripheral) {
         Peripheral = peripheral;

         Services = new CBtServices(peripheral);
      }

      public async Task Scan() {
         await Services.Scan();
      }
   }
}
