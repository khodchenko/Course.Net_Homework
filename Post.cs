﻿using System;


public class Post
{
    public int Id { get; set; }
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
}