Feature: AppointmentServiceTests
As a Client
I want to add new Appointment through API
In order to make it available for applications.

    Background:
        Given the Endpoint https://localhost:7096/api/v1/appointments is available

    @appointment-adding
    Scenario: Add Appointment with unique Name
        When a Post Request is sent to
          | userId   | technicianId               |
          | 1 | 2 | 
        Then A Response  is received with Status of 200
        And a Appointment Resource is included in Response Body
          | Id | userId   | technicianId               | 
          | 1  | 1 | 2 | 