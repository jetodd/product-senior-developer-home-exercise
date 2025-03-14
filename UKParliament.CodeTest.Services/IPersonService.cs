﻿using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services;

public interface IPersonService
{
    Person? GetPerson(int id);
    IEnumerable<Person> GetPeople();
    void UpdatePerson(Person person);
    void AddPerson(Person person);
}
