import { useEffect, useState } from 'react';
import { CryptoCoin } from '../../models/CryptoCoin';
import { CryptoCoinService } from '../../services/StudentService';
import "./CryptoCoinList.css";

function CryptoCoinList() {
   const [cryptoCoins, setCryptoCoins] = useState([] as CryptoCoin[]);    // State to store the list of students
   const [selectedCryptoCoin, setSelectedCryptoCoin] = useState<CryptoCoin | null>(null); // State to store the selected coin for editing
   const [isEditing, setIsEditing] = useState(false); // State to track whether editing mode is active
   const [isAdding, setIsAdding] = useState(false);
   const [newCryptoCoin, setNewCryptoCoin] = useState({
    name: '',
    amount: 0,
    buyPrice: 0,
    currentPrice: 0,
  });

  // Fetch the list of students when the component mounts
  const fetchCryptoCoins = async () => {
    try {
      const cryptoCoinsData = await CryptoCoinService.getAll();
      setCryptoCoins(cryptoCoinsData);
    } catch (error) {
      console.error('Error fetching cryptoCoins:', error);
    }
  };

  useEffect(() => {
    fetchCryptoCoins();
  }, []);

  const handleEditClick = (cryptoCoin: CryptoCoin) => {
    // Enable editing mode and set the selected cryptoCoin for editing
    setIsEditing(true);
    setSelectedCryptoCoin(cryptoCoin);
  };

  const handleDeleteClick = async (cryptoCoinId: number) => {
    // Delete the cryptoCoin and update the list of cryptoCoins
    try {
      await CryptoCoinService.delete(cryptoCoinId);
      // Remove the deleted cryptoCoin from the list
      setCryptoCoins((prevCryptoCoins) => prevCryptoCoins.filter((cryptoCoin) => cryptoCoin.id !== cryptoCoinId));
    } catch (error) {
      console.error('Error deleting cryptoCoin:', error);
    }
  };

  const handleSaveEdit = async () => {
    if (selectedCryptoCoin) {
      try {
        // Update the cryptoCoin and refresh the cryptoCoin list
        await CryptoCoinService.update(selectedCryptoCoin);
        setIsEditing(false);
        setSelectedCryptoCoin(null);
        // Refresh the cryptoCoin list
        const updatedCryptoCoins = await CryptoCoinService.getAll();
        setCryptoCoins(updatedCryptoCoins);
      } catch (error) {
        console.error('Error updating cryptoCoin:', error);
      }
    }
  };

  const handleCancelEdit = () => {
    // Cancel editing mode and clear the selected cryptoCoin
    setIsEditing(false);
    setSelectedCryptoCoin(null);
  };
  
  const handleAddClick = () => {
    setIsAdding(true);
  };

  const handleAddCoin = async () => {
    try {
      // Create a new coin and add it to the list
      await CryptoCoinService.create(newCryptoCoin);
      // Clear the form and hide it
      setNewCryptoCoin({
        name: '',
        amount: 0,
        buyPrice: 0,
        currentPrice: 0,
      });
      setIsAdding(false);
      // Refetch cryptoCoins after adding
      fetchCryptoCoins();
    } catch (error) {
      console.error('Error adding cryptoCoin:', error);
    }
  };

  return (
    <div>
        <h1>Crypto Coins List</h1>
        <button onClick={handleAddClick}>Add</button>
        {isAdding && (
          <div>
            <h2>Add Crypto Coin</h2>
            <input
              type="text"
              placeholder="Name"
              value={newCryptoCoin.name}
              onChange={(e) => setNewCryptoCoin({ ...newCryptoCoin, name: e.target.value })}
            />
            <input
              type="number"
              placeholder="Amount"
              value={newCryptoCoin.amount}
              onChange={(e) => setNewCryptoCoin({ ...newCryptoCoin, amount: Number(e.target.value) })}
            />
            <input
              type="number"
              placeholder="Buy Price"
              value={newCryptoCoin.buyPrice}
              onChange={(e) => setNewCryptoCoin({ ...newCryptoCoin, buyPrice: Number(e.target.value) })}
            />
            <input
              type="number"
              placeholder="Current Price"
              value={newCryptoCoin.currentPrice}
              onChange={(e) => setNewCryptoCoin({ ...newCryptoCoin, currentPrice: Number(e.target.value) })}
            />
            <button onClick={handleAddCoin}>Add Coin</button>
          </div>
        )}
        <table className="styled-table">
            <thead>
            <tr>
                <th>Name</th>
                <th>Amount</th>
                <th>Buy Price</th>
                <th>Current Price</th>
                <th> </th>
            </tr>
            </thead>
            <tbody>
            {cryptoCoins.map((coin) => (
                <tr key={coin.id}>
                    <td>{coin.name}</td>
                    <td>{coin.amount}</td>
                    <td>{coin.buyPrice}</td>
                    <td>{coin.currentPrice}</td>
                    <td> 
                        <button onClick={() => handleEditClick(coin)}>Edit</button>
                        <button onClick={() => handleDeleteClick(coin.id)}>Delete</button>
                    </td>
                </tr>
            ))}
            </tbody>
        </table>
        {isEditing ? (
            <div>
                <h2>Edit Crypto Coin</h2>
                <input
                type="text"
                value={selectedCryptoCoin?.name || ''}
                //onChange={(e) => setSelectedCryptoCoin({ ...selectedCryptoCoin, name: e.target.value })}
                />
                <input
                type="number"
                value={selectedCryptoCoin?.amount || ''}
                //onChange={(e) => setSelectedCryptoCoin({ ...selectedCryptoCoin, amount: Number(e.target.value) })}
                />
                <button onClick={handleSaveEdit}>Save</button>
                <button onClick={handleCancelEdit}>Cancel</button>
            </div>
        ) : null}
    </div>
  );
}

export default CryptoCoinList;

// https://www.youtube.com/watch?v=IGBRYTpgyg4&ab_channel=FollowAndrew
// https://dev.to/dcodeyt/creating-beautiful-html-tables-with-css-428l


// markan

// lyfecucle of components in react
// https://www.w3schools.com/react/react_lifecycle.asp
// https://www.w3schools.com/react/react_memo.asp 
// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Event_loop
// https://www.youtube.com/watch?v=8aGhZQkoFbQ