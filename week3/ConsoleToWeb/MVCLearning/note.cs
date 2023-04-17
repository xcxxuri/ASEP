/* MVC: model view controller

SQL (data layer) -> Entities ORMs -> 
Models (map entities to other data types) DTO : Data Transfer Object ->
C# Data object has data that comes from more than one entity ->
Controller recueves data from services (which got its information from repositiories) ->
View




Employee + Department + Manager
Person Information C#: this Person information in c# object has information from three entities. that is why we need to use DTO

Employee Name
Department name(only id is connecting Employee and Department, so to get Department name) 
Manager Name


Dependancy Injection: a design pattern that allows us to achieve loose coupling of code between objects and collabrators
Instead of Instantiating objects or using static references, we use constructor injection in order to use our objects

upcasting, Host:
static (global scope) => singleton
transient => scope that changes per implementation
scoped => a scope that changes per connection

*/
