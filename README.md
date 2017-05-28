# hexagonalThis
A simple kata to live-code with Alistair about Hexagonal Architecture

## Steps (carpaccio style)

1. Test drive the design of the business-logic API (domain). This first version of the business logic returns an hard-coded result.
1. Write another acceptance test __mocking a right-side adapter__ this time (repository/service provider) to improve the business-logic which now is using it (instead of providing hard-coded values).
1. Write another acceptance test to test-drive the usage of __a real left-side (ClI) adapter__ in the process. Introduce here an "hexagon" wrapper onto the business logic (to explicit the architectural pattern for the years to come ;-)
1. Write a ClI CONSOLE application (embedding the right-side mock) to __get end-users feedbacks about the way we will soon ask questions to the system__
1. Test drive __a real right-side adapter__ (eg. An external service provider or a file adapter)
1. Test drive __a JSON (left side) Adapter through an acceptance test
1. Plug the whole set into a Web API and deliver it _to gather end-users feedbacks__
1. Add other ports and adapters (e.g.: monitoring probe, a database repository, other service providers)

