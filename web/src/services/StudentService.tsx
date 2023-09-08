import axios from 'axios';
import { CryptoCoin } from '../models/CryptoCoin';

const API_BASE_URL = 'http://localhost:5000/api/crypto-coins';

export const CryptoCoinService = {
  // Fetch all CryptoCoins
  getAll: async (): Promise<CryptoCoin[]> => {
    try {
      const response = await axios.get(API_BASE_URL);
      console.log(response.data);
      return response.data;
    } catch (error) {
      console.error('Error fetching CryptoCoins:', error);
      throw error;
    }
  },

  // Get a CryptoCoin by ID
  getById: async (cryptoCoinId: number): Promise<CryptoCoin | null> => {
      try {
        const response = await axios.get(`${API_BASE_URL}/${cryptoCoinId}`);
        return response.data;
      } catch (error) {
        console.error(`Error fetching CryptoCoin with ID ${cryptoCoinId}:`, error);
        throw error;
      }
    },

  // Create a new CryptoCoin
  create: async (newCryptoCoin: Omit<CryptoCoin, 'id'>): Promise<CryptoCoin> => {
    try {
      const response = await axios.post(API_BASE_URL, newCryptoCoin);
      return response.data;
    } catch (error) {
      console.error('Error creating CryptoCoin:', error);
      throw error;
    }
  },

  // Update a CryptoCoin
  update: async (cryptoCoin: CryptoCoin): Promise<CryptoCoin> => {
    try {
      const response = await axios.put(`${API_BASE_URL}/${cryptoCoin.id}`, cryptoCoin);
      return response.data;
    } catch (error) {
      console.error('Error updating CryptoCoin:', error);
      throw error;
    }
  },

  // Delete a CryptoCoin
  delete: async (cryptoCoinId: number): Promise<void> => {
    try {
      await axios.delete(`${API_BASE_URL}/${cryptoCoinId}`);
    } catch (error) {
      console.error('Error deleting CryptoCoin:', error);
      throw error;
    }
  },
};
