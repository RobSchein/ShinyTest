using Shiny.BluetoothLE;

namespace MyNamespace.Classes {
   public class CBtCharacteristics {
      public readonly List<CBtCharacteristic> CharacteristicList = new();
      public readonly List<string> CharacteristicListStr = new();
      private readonly Dictionary<string, CBtCharacteristic> CharacteristicDict = new();
      private readonly IPeripheral? Peripheral;
      public CBtCharacteristics(IPeripheral? peripheral) {
         Peripheral = peripheral;
      }

      public async Task Scan(BleServiceInfo ServiceInfo) {
         try {
            var CharacteristicListReadOnly = await Peripheral.GetCharacteristicsAsync(ServiceInfo.Uuid);

            CharacteristicList.Clear();
            CharacteristicListStr.Clear();
            CharacteristicDict.Clear();
            for (int i = 0; i < CharacteristicListReadOnly.Count; i++)
            {
               if (Constants.CharacteristicUuidMap.ContainsKey(CharacteristicListReadOnly[i].Uuid)) {
// Next line is how I had been filtering out the characteristics that are not in the Constants.CharacteristicUuidMap
//                if (ServiceInfo.Uuid == CharacteristicListReadOnly[i].Service.Uuid) {
                     CBtCharacteristic Characteristic = new(Peripheral, (BleCharacteristicInfo)CharacteristicListReadOnly[i]);
                     CharacteristicListStr.Add(Constants.CharacteristicUuidMap[CharacteristicListReadOnly[i].Uuid]);
                     CharacteristicDict.Add(Constants.CharacteristicUuidMap[CharacteristicListReadOnly[i].Uuid], Characteristic);
//                }
               }
            }
         } catch (KeyNotFoundException) {
            Console.WriteLine("Key not found");
         } catch (ArgumentNullException) {
            Console.WriteLine("Argument Null Exception");
         }
      }

      public CBtCharacteristic GetCharacteristic(string name) {
         return CharacteristicDict[name];
      }

      public void WriteCharacteristic(string name, byte[] value) {
         if (Peripheral != null) {
            CBtCharacteristic Characteristic = CharacteristicDict[name];
            Characteristic.Write(value);
         }
      }
      public async void ReadCharacteristic(string name) {
         if (Peripheral != null) {
            CBtCharacteristic Characteristic = CharacteristicDict[name];
            await Characteristic.Read();
         }
      }
   }
}
