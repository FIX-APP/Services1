Feature: ArtifactServiceTests
As a Client
I want to add new Artifact through API
In order to make it available for applications.

    Background:
        Given the Endpoint https://localhost:7096/api/v1/artifacts is available

    @artifact-adding
    Scenario: Add Artifact with unique Name
        When a Post Request is sent
          | name  | url       | userId |
          | Sample | A Sample Tutorial | 1          |
        Then A Response  is received with Status 200
        And a Artifact Resource is included in Response Body
          | Id | name  | url       | userId |
          | 1  | Sample | A Sample Tutorial | 1          |

