const fetch = require('node-fetch');

function generateRandomData() {
  return {
    name: `Coin${Math.floor(Math.random() * 100)}`,
    amount: Math.floor(Math.random() * 1000),
    buyPrice: parseFloat((Math.random() * 1000).toFixed(2)),
    currentPrice: parseFloat((Math.random() * 1000).toFixed(2)),
  };
}

async function populateDatabase() {
  const apiEndpoint = 'http://localhost:5000/crypto-coins'; // Replace with your API endpoint URL
  const numberOfRequests = 200;

  for (let i = 0; i < numberOfRequests; i++) {
    const data = generateRandomData();

    const requestOptions = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    };

    try {
      const response = await fetch(apiEndpoint, requestOptions);

      if (!response.ok) {
        throw new Error(`Request failed with status ${response.status}`);
      }

      console.log(`Request ${i + 1} succeeded.`);
    } catch (error) {
      console.error(`Request ${i + 1} failed: ${error.message}`);
    }
  }

  console.log('All requests completed');
}

// Call the function to start populating the database
populateDatabase();
