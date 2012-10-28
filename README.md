CISServer
=========

Customer Interaction Services Server

Introduction
============

The main idea behind CIS is to improve the customer experience by simplifing the process
of interacting with varsious services.

The current prototype uses a mobile phone to identify specific service provider markers
(such as QRT markers), called hotspots. By scanning this marker he can get access to a new
way to interact with the services available at those hotspots.

For example imagine that you go to a hotel and a marker is place somewhere in the room, by scanning
that marker you can access room-service and other services straight from your phone. The same principle
can apply to many other situations such as bars, restaurants, karaoke etc.

Prototype architecture
======================

1. Mobile app
2. Cloud services (RESTful API/storage)
3. Real-time management platforms

The prototype features an Android app that connects to the CIS Azure Cloud Service and a web-based
real time management platform where service requests are processed.
