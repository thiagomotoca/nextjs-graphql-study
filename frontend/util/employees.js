import { gql } from '@apollo/client'
import client from "./apollo-client"

export async function getAllEmployeeIds() {
  const { data } = await client.query({
    query: gql`
      query {
        employees {
          id
        }
      }
      `,
  });

  return data.employees.map(employee => {
    return employee.id
  })
}

export async function getAllEmployees() {
  const { data } = await client.query({
    query: gql`
      query {
        employees {
          id,
          name
          relatives {
            id,
            name
          }
        }
      }
      `,
  });

  return data.employees;
}

export async function getEmployee(id) {
  const { data } = await client.query({
    query: gql`
      query {
        employees(where: {id: {eq: "${id}"}}) {
          id,
          name
          relatives {
            id,
            name
          }
        }
      }
      `,
  });

  return data.employees[0];
}