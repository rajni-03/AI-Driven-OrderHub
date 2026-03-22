# AI-Driven Order Hub 🚀

## 💡 Overview

A cloud-native ordering system designed to handle high-scale order processing using Azure services and .NET.

## 🚀 Problem

Traditional ordering systems struggle with scalability, delayed processing, and lack of intelligent recommendations.

## 🏗️ Solution

Built an event-driven architecture using Azure Service Bus and .NET APIs to ensure scalable and reliable order processing.

## ⚙️ Tech Stack

* Backend: .NET Web API
* Frontend: Blazor
* Cloud: Azure (Service Bus, Functions, Cosmos DB)

## 🔥 Features

* Asynchronous order processing using Azure Service Bus
* Scalable cloud architecture
* AI-based product recommendations (in progress)

## 🧠 Engineering Decisions

* Used **Azure Service Bus** to decouple order processing and improve scalability
* Implemented **event-driven architecture** for handling high traffic efficiently
* Chose **Azure Functions** for cost-effective serverless processing
* Used **Cosmos DB** for flexible and scalable data storage
* Designed APIs to be **stateless and modular**

  
## 🏗️ Architecture Flow

1. User places an order via Blazor UI
2. Request goes to .NET API
3. API publishes order message to Azure Service Bus
4. Azure Function consumes the message
5. Order is processed asynchronously
6. AI module generates product recommendations
7. Data is stored in Cosmos DB
8. Response is sent back to user


## 🚀 Future Improvements

* Real-time tracking using SignalR
* Advanced AI recommendations
