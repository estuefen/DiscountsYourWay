﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DiscountsYourWay.DefaultPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="carousel slide" id="myCarousel">
        <ol class="carousel-indicators">
            <li class="active" data-slide-to="0" data-target="#myCarousel"></li>
            <li data-slide-to="1" data-target="#myCarousel"></li>
            <li data-slide-to="2" data-target="#myCarousel"></li>
        </ol>
        <div class="carousel-inner">
            <div class="item active" id="slide1">
                <div class="carousel-caption">
                    <h4>Bootstrap 3</h4>
                    <p>Learn how to build your first responsive website with the brand new Twitter Bootstrap 3!</p>
                </div>
            </div>
            <div class="item" id="slide2">
                <div class="carousel-caption">
                    <h4>Learn to code a website in 4-hours!</h4>
                    <p>PSD to HTML5 &amp; CSS3 is a popular Udemy course that has helped thousands of aspiring web designers launch their web design career.</p>
                </div>
            </div>
            <div class="item" id="slide3">
                <div class="carousel-caption">
                    <h4>Web Hosting 101</h4>
                    <p>Learn how to buy a perfect domain name and hosting package, and get your website live on the web with ease.</p>
                </div>
            </div>
        </div>
        <a class="left carousel-control" data-slide="prev" href="#myCarousel"><span class="icon-prev"></span></a>
        <a class="right carousel-control" data-slide="next" href="#myCarousel"><span class="icon-next"></span></a>
    </div>
</asp:Content>
