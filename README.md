# AIS_1lab

Academic team project developed as part of a C#/.NET university course.

## Overview

The project is a desktop application built with a layered architecture,
separating domain models, business logic and data access.

## Tech Stack

- C#
- .NET 8
- Entity Framework 6
- Dapper
- SQL Server / LocalDB
- Ninject
- Git

## Architecture

- `Model` - domain models and interfaces
- `BusinessLogic` - business logic and dependency configuration
- `DataAccessLayer` - repositories and database access
- `ConsoleApp` - application entry point

The Data Access Layer contains implementations using both
Entity Framework and Dapper.

Dependency Injection is configured with Ninject.

## What I Practiced

- Layered application architecture
- Repository pattern
- Entity Framework
- Dapper
- SQL and CRUD operations
- Dependency Injection
- Git-based team development

## Project Status

Educational project completed as part of university coursework.

This project represents an early stage of my C#/.NET development
and contains architectural decisions that I would approach differently
with current knowledge.
