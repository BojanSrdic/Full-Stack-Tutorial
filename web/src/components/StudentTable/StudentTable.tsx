import { useEffect, useState } from 'react';
import { CryptoCoin } from '../../models/CryptoCoin';
import { CryptoCoinService } from '../../services/StudentService';
import "./StudentTable.css";

function StudentTable() {
  const [coin, setCryptoCoin] = useState([] as CryptoCoin[]);    // State to store the list of students
 

  useEffect(() => {
    // Fetch the list of students when the component mounts
    async function fetchStudents() {
      try {
        const coinData = await CryptoCoinService.getAll();
        setCryptoCoin(coinData);
      } catch (error) {
        console.error('Error fetching students:', error);
      }
    }

    fetchStudents();
  }, []);

  return (
    <div>
      <h1>Crypto Coins List</h1>
      <ul>
        {coin.map((coin) => {
          return (
            <div>
              <li key={coin.id}>
                {coin.name}, Amount: {coin.amount}
      
              </li>
            </div>
          )
        })}
      </ul>
    </div>
  );
}

export default StudentTable;

// funkcionalen komponente a renije su bile klasne

/*

 //const [students, setStudents] = useState<Student[]>([]);
  //const [selectedStudent, setSelectedStudent] = useState<Student | null>(null); // State to store the selected student for editing
  //const [isEditing, setIsEditing] = useState(false); // State to track whether editing mode is active

const handleEditClick = (student: Student) => {
    // Enable editing mode and set the selected student for editing
    setIsEditing(true);
    setSelectedStudent(student);
  };

  const handleDeleteClick = async (studentId: number) => {
    // Delete the student and update the list of students
    try {
      await StudentService.delete(studentId);
      // Remove the deleted student from the list
      setStudents((prevStudents) => prevStudents.filter((student) => student.id !== studentId));
    } catch (error) {
      console.error('Error deleting student:', error);
    }
  };

  const handleSaveEdit = async () => {
    if (selectedStudent) {
      try {
        // Update the student and refresh the student list
        await StudentService.update(selectedStudent);
        setIsEditing(false);
        setSelectedStudent(null);
        // Refresh the student list
        const updatedStudents = await StudentService.getAll();
        setStudents(updatedStudents);
      } catch (error) {
        console.error('Error updating student:', error);
      }
    }
  };

  const handleCancelEdit = () => {
    // Cancel editing mode and clear the selected student
    setIsEditing(false);
    setSelectedStudent(null);
  };

*/

/*

<div>
      <table>
        <tr>
          <th>Company</th>
          <th>Contact</th>
          <th>Country</th>
        </tr>
        
        <tr>
          <td>Magazzini Alimentari Riuniti</td>
          <td>Giovanni Rovelli</td>
          <td>Italy</td>
        </tr>
      </table>
    </div>

*/
