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
	std::vector<char>* vBuffer;
	boost::asio::mutable_buffer incoming;
	void start_listening();
	void handle_receive(const boost::system::error_code& error, std::size_t numBytes);
};

