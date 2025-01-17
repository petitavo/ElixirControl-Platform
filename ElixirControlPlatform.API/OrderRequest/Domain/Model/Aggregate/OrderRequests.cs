using ElixirControlPlatform.API.OrderRequest.Domain.Model.Commands;

namespace ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;

public class OrderRequests
{
    public int Id { get; private set;}
    
    public int Quantity { get; private set; }
    public int Price { get; private set; }
    public string Status { get; private set; }
    public string OrderNumber  { get; private set; }
    public string OrderDate { get; private set; }
        
    // Additional fields
    public string TransportCondition { get; private set; }
    public string PaymentMethod { get; private set; }
    public string ConsumerPhone { get; private set; }
    public string ProducerPhone { get; private set; }
    public string PaymentTerms { get; private set; }
    public string Date { get; private set; }
    public string DeliveryDate { get; private set; }
    public string Type { get; private set; }

    public OrderRequests()
    {
        this.Quantity = 0;
        this.Price = 0;
        this.Status = string.Empty;
        this.OrderNumber = string.Empty;
        this.OrderDate = string.Empty;
        this.TransportCondition = string.Empty;
        this.PaymentMethod = string.Empty;
        this.ConsumerPhone = string.Empty;
        this.ProducerPhone = string.Empty;
        this.PaymentTerms = string.Empty;
        this.Date = string.Empty;
        this.DeliveryDate = string.Empty;
        this.Type = string.Empty;
        
    }

    public OrderRequests(CreateOrderRequestsCommand requestsCommand) : this()
    {
        Quantity = requestsCommand.Quantity;
        Price = requestsCommand.Price;
        Status = requestsCommand.Status;
        OrderNumber = requestsCommand.OrderNumber;
        OrderDate = requestsCommand.OrderDate;
        TransportCondition = requestsCommand.TransportCondition;
        PaymentMethod = requestsCommand.PaymentMethod;
        ConsumerPhone = requestsCommand.ConsumerPhone;
        ProducerPhone = requestsCommand.ProducerPhone;
        PaymentTerms = requestsCommand.PaymentTerms;
        Date = requestsCommand.Date;
        DeliveryDate = requestsCommand.DeliveryDate;
        Type = requestsCommand.Type;
    }    
    
    public void UpdateStatus(UpdateOrderRequestsStatusByIdCommand byIdCommand)
    {
        this.Status = byIdCommand.Status;
    }
    
    public void UpdateOrderRequestsById(UpdateOrderRequestsByIdCommand command)
    {
        this.Quantity = command.Quantity;
        this.Price = command.Price;
        this.Status = command.Status;
        this.OrderNumber = command.OrderNumber;
        this.OrderDate = command.OrderDate;
        this.TransportCondition = command.TransportCondition;
        this.PaymentMethod = command.PaymentMethod;
        this.ConsumerPhone = command.ConsumerPhone;
        this.ProducerPhone = command.ProducerPhone;
        this.PaymentTerms = command.PaymentTerms;
        this.Date = command.Date;
        this.DeliveryDate = command.DeliveryDate;
        this.Type = command.Type;
    }
}