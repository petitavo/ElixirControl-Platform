﻿using ElixirControlPlatform.API.OrderManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.OrderManagement.Domain.Repositories;
using ElixirControlPlatform.API.OrderManagement.Domain.Services;
using ElixirControlPlatform.API.Shared.Domain.Repositories;
using ElixirControlPlatform.API.Profiles.Domain.Repositories;
using System.Threading.Tasks;

namespace ElixirControlPlatform.API.OrderManagement.Application.Internal.CommandServices;

/// <summary>
/// Order command service
/// </summary>
public class OrderCommandService(IOrderRepository orderRepository, IProfileRepository profileRepository, IUnitOfWOrk unitOfWork) : IOrderCommandService
{

    
    public async Task<Order?> Handle(CreateOrderCommand command, Guid profileId)
    {
        var profile =  await profileRepository.GetProfileByIdAsync(profileId);

        if (profile is null) throw new Exception("Profile not found");
        
        var order = new Order(command, profileId);
        
        await orderRepository.AddAsync(order);
        await unitOfWork.CompleteAsync();
        
        return order;
    }
    public async Task<Order?> Handle(UpdateOrderStatusCommand command)
    {
        var order = await orderRepository.FindByIdAsync(command.Id);
        if (order == null)
        {
            return null;
        }
        order.UpdateStatus(command);
        await unitOfWork.CompleteAsync();
        return order;
    }
    
    public async Task<Order?> Handle(DeleteOrderCommand command)
    {
        var order = await orderRepository.FindByIdAsync(command.Id);
        if (order is null) throw new Exception("Order not found");
        orderRepository.Remove(order);
        await unitOfWork.CompleteAsync();
        return order;
    }
}