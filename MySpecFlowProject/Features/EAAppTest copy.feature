Feature: Login to EAEAppTest and Search for Playwright copy

    @smoke
    Scenario: Test Login for EAE Test App copy
        Given I navigate to the EAE Test App page
        And I click on the Login link
        And I enter following credentials:
        | UserName | Password |
        | admin | password |
        Then I see EMP list link
