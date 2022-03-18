import { useRouter } from 'next/router'
import Layout from '../components/layout';
import { getAllEmployees } from '../util/employees'

export default function Home({ employees }) {
  const router = useRouter()

  return (
    <Layout>
      {employees.map(employee => (
        <button key={employee.id} type="button" class="btn btn-primary me-2" onClick={() => router.push(`/employees/${employee.id}`)}>
          {employee.name} <span class="badge bg-secondary">{employee.relatives.length}</span>
        </button>
      ))}
    </Layout>
  );
}

export async function getStaticProps() {
  const data = await getAllEmployees();

  return {
    props: {
      employees: data,
    },
  };
}