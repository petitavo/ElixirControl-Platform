﻿namespace ElixirControlPlatform.API.CustomerManagement.Interfaces.REST.Resources;

/// <summary>
/// Resource to create a client
/// </summary>
/// <param name="PersonName"></param>
/// <param name="Dni"></param>
/// <param name="Email"></param>
/// <param name="BusinessName"></param>
/// <param name="Phone"></param>
/// <param name="Address"></param>
/// <param name="Country"></param>
/// <param name="City"></param>
/// <param name="Ruc"></param>
public record CreateClientResource(string PersonName, int Dni, string Email, string BusinessName, int Phone, string Address, string Country, string City, int Ruc);

