import Link from 'next/link'
import Layout from '../../components/layout'
import { getAllEmployeeIds, getEmployee } from '../../util/employees'

export async function getStaticProps({ params }) {
  const employee = await getEmployee(params.id)
  return {
    props: {
      employee
    }
  }
}

export async function getStaticPaths() {
  const ids = await getAllEmployeeIds()
  const paths = ids.map(id => {
    return {
      params: {
        id: id
      }
    }
  })
  
  return {
    paths,
    fallback: false
  }
}

export default function Employee({ employee }) {
  return (
    <Layout>
      {employee.relatives.map(relative => (
        <p>{relative.name}</p>
      ))}
      <Link href="/">
        <a>Back to home</a>
      </Link>
    </Layout>
  );
}