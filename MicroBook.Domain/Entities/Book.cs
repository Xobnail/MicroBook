﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MicroBook.Domain.Entities;

/// <summary>
/// Book.
/// </summary>
public class Book
{
    /// <summary>
    /// Book Id.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Book name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Book's author.
    /// </summary>
    [ForeignKey("Id")]
    public Author? Author { get; set; }

    /// <summary>
    /// Book's author Id.
    /// </summary>
    [JsonIgnore]
    public int? AuthorId { get; set; }

    /// <summary>
    /// Book edition.
    /// </summary>
    public string? Edition { get; set; }

    /// <summary>
    /// Amount of pages in book.
    /// </summary>
    public int? AmountOfPages { get; set; }

    /// <summary>
    /// Amount of books on storage.
    /// </summary>
    public int? Amount { get; set; }

    /// <summary>
    /// Language of book.
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// Book price.
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Weight of book.
    /// </summary>
    public string? Weight { get; set; }

    /// <summary>
    /// Size of book.
    /// </summary>
    public string? Size { get; set; }

    /// <summary>
    /// Book publish date.
    /// </summary>
    public DateTime? PublishDate { get; set; }

    /// <summary>
    /// Book release date.
    /// </summary>
    public DateTime? ReleaseDate { get; set; }

    /// <summary>
    /// Book's publisher.
    /// </summary>
    [ForeignKey("Id")]
    public Publisher? Publisher { get; set; }

    /// <summary>
    /// Book's publisher Id.
    /// </summary>
    [JsonIgnore]
    public int? PublisherId { get; set; }

    /// <summary>
    /// Book's ISBN.
    /// </summary>
    public string? ISBN { get; set; }

    /// <summary>
    /// Age restriction of book.
    /// </summary>
    public string? AgeRestrictions { get; set; }

    /// <summary>
    /// One to many relationship with Orders.
    /// </summary>
    [JsonIgnore]
    public ICollection<Order> Orders { get; set; } = [];
}