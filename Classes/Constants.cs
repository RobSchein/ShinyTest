namespace MyNamespace.Classes {
   public static class Constants {


      //const string ServiceUuid = "FFF0";
      //public static string ScanServiceUuid { get; set;}
      public const string DeviceName = "LeashMinder";
      public const string WriteValue = "";
      public const string DeviceUuid = "243b9770-c03e-461c-9785-6ed82a7b9109";

      public const string ImuServiceUuid     = "243b9770-c03e-461c-9785-6ed82a7b9109";
      public const string ImuLimit0Uuid      = "018178f7-e567-4663-ba0c-c6a969bc4d8c";
      public const string ImuLimit1Uuid      = "ebca2eaa-5fea-4335-999b-76b549fce280";
      public const string ImuLimit2Uuid      = "7d3c69e4-14cd-4dcb-9d76-16ba4a0cf637";
      public const string ImuDeadbandUuid    = "b702a282-6544-41f8-b6e5-80d9d9ddefdd";
      public const string ImuEnabledUuid     = "806b423f-31e5-41a1-b334-dd3a25816603";

      public const string MicServiceUuid     = "846c2aa8-2e7a-48ca-8d48-6298d11d62c8";
      public const string MicLimit0Uuid      = "03a152dd-3595-4433-9153-ff2f02e27ef7";
      public const string MicLimit1Uuid      = "d37f3688-81f0-4c37-89e5-9b55c7b65d30";
      public const string MicLimit2Uuid      = "3802b69c-cd7f-44ae-bfd2-98d942058485";
      public const string MicDeadbandUuid    = "9aaefb8d-47e7-4bc2-bf14-f4c34efdacbc";
      public const string MicEnabledUuid     = "a89658c8-ee70-4f5d-b3ce-5961a4572b92";

      public const string StrainServiceUuid  = "f0db9514-0565-4f48-9719-668a82115771";
      public const string StrainLimit0Uuid   = "7085f683-a450-4241-a1e4-ecc958ad9c45";
      public const string StrainLimit1Uuid   = "e3ad9933-0332-46e8-94a2-ebb9d16e4922";
      public const string StrainLimit2Uuid   = "d7aa8b06-03eb-4114-844d-bee263c81b89";
      public const string StrainDeadbandUuid = "d782c68f-fcd1-4334-9ef2-0ce740c787fb";
      public const string StrainEnabledUuid  = "2404116a-f034-47a6-88ce-c3511204b611";

      public static Dictionary<string, string> ServiceUuidMap = new Dictionary<string, string>() {
         { ImuServiceUuid,    "Imu Service" },
         { MicServiceUuid,    "Microphone Service" },
         { StrainServiceUuid, "Pull Sensor Service" }
      };
         

      public static Dictionary<string, string> CharacteristicUuidMap = new Dictionary<string, string>() {
         { ImuLimit0Uuid,        "ImuLimit0" },
         { ImuLimit1Uuid,        "ImuLimit1" },
         { ImuLimit2Uuid,        "ImuLimit2" },
         { ImuDeadbandUuid,      "ImuDeadband" },
         { ImuEnabledUuid,       "ImuEnabled" },
         { MicLimit0Uuid,        "MicLimit0" },
         { MicLimit1Uuid,        "MicLimit1" },
         { MicLimit2Uuid,        "MicLimit2" },
         { MicDeadbandUuid,      "MicDeadband" },
         { MicEnabledUuid,       "MicEnabled" },
         { StrainLimit0Uuid,      "StrainLimit0" },
         { StrainLimit1Uuid,      "StrainLimit1" },
         { StrainLimit2Uuid,      "StrainLimit2" },
         { StrainDeadbandUuid,   "StrainDeadband" },
         { StrainEnabledUuid,    "StrainEnabled" }
      };


      public static readonly (string ServiceUuid, string CharacteristicUuid) WriteCharacteristic = (
            "FFF0",
            "FFF2"
      );

      public static readonly (string ServiceUuid, string CharacteristicUuid) ReadCharacteristic = (
            "",
            ""
      );

      public static readonly (string ServiceUuid, string CharacteristicUuid) NotifyCharacteristic = (
            "",
            ""
      );
   }
}
