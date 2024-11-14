﻿namespace ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Commands;

public record UpdateAgingByBatchCommand(
    string BarrelType, 
    string StartDate, 
    string EndDate, 
    int AgingDurationMonths, 
    int InspectionsPerformed, 
    string InspectionResult);