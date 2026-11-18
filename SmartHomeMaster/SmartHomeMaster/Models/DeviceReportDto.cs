namespace SmartHomeMaster.Models;

public record DeviceReportDto(int DeviceId, string Model, string Type, double Power, string RoomTitle, int Floor);
