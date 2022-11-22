Feature: UserServiceTests
As a Client
I want to add new User through API
In order to make it available for applications.

    Background:
        Given the Endpoint https://localhost:7096/api/v1/users is available

    @user-adding
    Scenario: Add User with unique Name
        When a Post Request is sent to users
          | name   | lastName          | cellphone | password | email | address | rol |
          | Sample | sampleName | 1         | 999999999         |12345       | sampleemail@hotmail.com        | c    |
        Then A Response  is received with Statuss 200
        And a User Resource is included in Response Body
          | Id |  name  | lastName   | cellphone | password  | email | address                 | rol |
          | 3  | Sample | sampleName | 1         | 999999999 |12345  | sampleemail@hotmail.com | c   |