Feature: DeleteSnack

@validSnackDeletion
Scenario: Delete snack
	Given a signed in admin user
    And the user added a snack with name "NewSnack", description "Desription" and value "2.99"
    When the user deletes the snack
    Then the message code should be "200"

@invalidSnackDeletion
Scenario: Delete snack (invalid)
	Given a signed in admin user
    When the user deletes a snack with an invalid id
    Then the message code should be "400"

@ForbiddenSnackDeletion
Scenario: Delete snack (forbidden)
	Given a signed in non admin user
    When the user deletes the snack
    Then the message code should be "403"