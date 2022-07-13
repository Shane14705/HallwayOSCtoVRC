#pragma once

#include <boost\asio.hpp>
#include <boost\array.hpp>
#include <boost\bind.hpp>

class OSCServer
{
public:
	OSCServer(boost::asio::io_context& io_context);
	

	~OSCServer();

private:
	boost::asio::ip::udp::socket socket_;
	//boost::array<char, 1024> vBuffer;
	std::vector<char> vBuffer;
	boost::asio::mutable_buffer incoming;
	boost::asio::ip::udp::endpoint myEP;
	void start_listening();
	void handle_receive(const boost::system::error_code& error, std::size_t numBytes);
};

