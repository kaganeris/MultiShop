﻿using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.OrderDetailId);
            value.ProductName = command.ProductName;
            value.ProductPrice = command.ProductPrice;
            value.ProductTotalPrice = command.ProductTotalPrice;
            value.ProductId = command.ProductId;
            value.OrderingId = command.OrderingId;
            value.ProductAmount = command.ProductAmount;
            await _repository.UpdateAsync(value);
        }
    }
}