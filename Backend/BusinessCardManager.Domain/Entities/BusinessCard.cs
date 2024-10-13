﻿namespace BusinessCardManager.Domain.Entities;
public class BusinessCard
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Photo { get; set; }
    public string Address { get; set; }
}
