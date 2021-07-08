# svelte-dotnet-reactive
A project to present full reactivity in a Svelte, .NET, ReactiveX stack.

## Goals

Frameworks like Firebase and Meteor do a lot to create reactivity to mutations in data. What if we were able to build a stack that had the flexibility to do the same, but with a stack of technologies that was fairly modular.

1. The technologies should be reactive through all layers.
1. The code and implementation should be as functional as possible.
1. <<Will come up with more>>
  
## Technologies
  
* **.NET Core with SignalR entrypoint** - This will allow for bi-drectional RPC, facilitating high-level pub/sub and simplified fetches (No Rest).
* **GraphQL** - All data and mutations will be handled through GraphQL against an abstracted DB provider in EF. Data subscriptions will happen through SignalR, but managed through .NET's interface to GraphQL.
* **TypeScript Model Projection** - Yes, TS is not the best of functional JS languages, but it is headed there, and it has ubiquitous support. Model projection will create proxy types in the client side for clean data transport.
* *ReactiveX ViewModels** - Create a ViewModel paradigm that implements Observables and manages data needed in views in the place of Stores. Views will implement and pass obeservables to descendant components.
* **Svelte UI** - Svelte is built from the ground up as a language-compiler to be reactive, clean, functional, and pretty simple. It should couple well with ReactiveX for full reactivity.

## Authentication and Authorization
  
Since the goal here is not to hammer out cool or best ways to authenticate, initially, we will just use a dead simple cookie, and then use that with the EF provider to pull in the cliams and context for the applications routes and graphql perms. As simple as possible, but no simpler. This all sounds good in my head, but once I dig in, it might need some rework.

 
