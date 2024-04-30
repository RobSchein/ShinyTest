using Shiny.BluetoothLE;

namespace MyNamespace.Classes {
   public class CBtServices {
      public readonly List<CBtService> ServiceList = new();
      public readonly List<string> ServiceListStr = new();
      private readonly Dictionary<string, CBtService> ServiceDict = new();
      private IPeripheral Peripheral;
      public CBtServices(IPeripheral peripheral) {
         Peripheral = peripheral;
      }

      public async Task Scan() {
         try {
            var ServicesListReadOnly = await Peripheral.GetServicesAsync();

            ServiceList.Clear();
            ServiceListStr.Clear();
            ServiceDict.Clear();
            for (int i = 0; i < ServicesListReadOnly.Count; i++)
            {
               if (Constants.ServiceUuidMap.ContainsKey(ServicesListReadOnly[i].Uuid)) {
                  CBtService Service = new(Peripheral, (BleServiceInfo)ServicesListReadOnly[i]);
                  ServiceList.Add(Service);
                  ServiceListStr.Add(Constants.ServiceUuidMap[ServicesListReadOnly[i].Uuid]);
                  ServiceDict.Add(Constants.ServiceUuidMap[ServicesListReadOnly[i].Uuid], Service);
               }
            }
         } catch (KeyNotFoundException) {
            Console.WriteLine("Key not found");
         } catch (ArgumentNullException) {
            Console.WriteLine("Argument Null Exception");
         }
      }

      public CBtService GetService(string name) {
         return ServiceDict[name];
      }
   }
}
