Feature: AddSnack

@validSnackCreation
Scenario: Add snack
	Given a signed in admin user
    And the user entered the snack name "Chocolate Chip Cookies"
    And the user entered the snack description "Chocolate Chip Cookies description"
    And the user entered the snack price "2.99"
    When the user adds the snack
    Then the message code should be "200"


@invalidSnackCreationOnlyEmptyName
Scenario: Add snack with empty name
	Given a signed in admin user
    And the user entered the snack name ""
    And the user entered the snack description "Chocolate Chip Cookies description"
    And the user entered the snack price "2.99"
    When the user adds the snack
    Then the message code should be "400"

@invalidSnackCreationOnlyEmptyDescription
Scenario: Add snack with empty description
	Given a signed in admin user
    And the user entered the snack name "Chocolate Chip Cookies"
    And the user entered the snack description ""
    And the user entered the snack price "2.99"
    When the user adds the snack
    Then the message code should be "400"


@invalidSnackCreationOnlyPriceLessThan1
Scenario: Add snack with a price less than 1
	Given a signed in admin user
    And the user entered the snack name "Chocolate Chip Cookies"
    And the user entered the snack description "Chocolate Chip Cookies description"
    And the user entered the snack price "0"
    When the user adds the snack
    Then the message code should be "400"

@invalidSnackCreationEmptyNameAndDescription
Scenario: Add snack with empty name and empty description
	Given a signed in admin user
    And the user entered the snack name ""
    And the user entered the snack description ""
    And the user entered the snack price "2.99"
    When the user adds the snack
    Then the message code should be "400"

@invalidSnackCreationEmptyNameAndPriceLessThan1
Scenario: Add snack with empty name and a price less than 1
	Given a signed in admin user
    And the user entered the snack name ""
    And the user entered the snack description "Chocolate Chip Cookies description"
    And the user entered the snack price "0"
    When the user adds the snack
    Then the message code should be "400"

@invalidSnackCreationEmptyDescriptionAndPriceLessThan1
Scenario: Add snack with empty description and a price less than 1
	Given a signed in admin user
    And the user entered the snack name "Chocolate Chip Cookies"
    And the user entered the snack description ""
    And the user entered the snack price "0"
    When the user adds the snack
    Then the message code should be "400"

@invalidSnackCreationEmptyNameEmptyDescriptionAndPriceLessThan1
Scenario: Add snack with empty name, empty description and a price less than 1
	Given a signed in admin user
    And the user entered the snack name ""
    And the user entered the snack description ""
    And the user entered the snack price "0"
    When the user adds the snack
    Then the message code should be "400"

@ForbiddenSnackAddition
Scenario: Add snack (forbidden)
	Given a signed in non admin user
    And the user entered the snack name "Chocolate Chip Cookies"
    And the user entered the snack description "Chocolate Chip Cookies description"
    And the user entered the snack price "2.99"
    When the user adds the snack
    Then the message code should be "403"