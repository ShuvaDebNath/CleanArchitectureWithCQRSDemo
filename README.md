# Clean Architecture With CQRS Pattern

In clean architecture, based on the picture, the domain and application layers remain in the center of the design which is known as core of the application. The domain layer contains enterprise logic and the application layer contains business logic. Generally, business logic is not sharable, it is for that particualr business only but enterprise logic can be shared across many related system.

# Advantages

=> Highly maintainable - It’s follows seperation of concern.
=> UI Independent - It is loosely coupled with UI layer. So, you can change UI without changing the core buisness.
=> Highly Testable - Apps built using this approach, and especially the core domain model and its business rules, are extremely testable.
=> Framework Independent - You can use any langulage like C#, Java, Python to implement clean architecture.
=> Scalable - Can implement CQRS pattern. So, it is highly scalable.

# CQRS Pattern

CQRS stands for Command and Query Responsibility Segregation. Main concern of this pattern is seperation of concern. It seperates read and command (insert, update, delete) operations. It is mostly used for performance and scalability.
