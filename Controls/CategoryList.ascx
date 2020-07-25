<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="Automobile_repair_shop.Controls.CategoryList" %>

<%= CreateHomeLinkHtml() %>

<% 
    foreach (string item in GetCategories())
    {
        Response.Write(CreateLinkHtml(item));
    }
%>